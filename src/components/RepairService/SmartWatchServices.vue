<template>
  <div class="Services-display-page-container">
  
      <div class="Services-Price-selector">
          <div class="Services-Display-template">
              <img :src="(services !== null && services.length > 0) ? getImageUrl(services[0].Image) : ''" class="Services-Display-templates-images">
              <div>{{ (services !== null && services.length > 0) ? services[0].DeviceName : '' }}</div>
          </div>
          <div class="Services-Add-template">
              <div id="Service-Head-line">Pick your repair service</div>
              <div class="Services-Pick-container">
                  <div v-for="(service, index) in services" :key="index" class="Service-Product">
                      <div class="Services-Image-Container">
                          <img class="Services-Image" :src="getServiceImageUrl(service.ServiceImage)" />
                      </div>
                      <div class="Services-Product-Details">
                          <div class="Service-Poduct-Details-Name">
                              <div>{{ service.ServiceName }}</div>
                              <div>
                                  <font-awesome-icon icon="info-circle" class="fa-icon-class" @click="showModal = true" />
                              </div>
                          </div>
                          <div class="Service-Poduct-Details-Price">
                              ₹{{ service.ServiceCost }}
                              <button class="btn btn-outline-primary Add-Price-Button" @click="toggleService(service)">
                                  {{ selectedServices.includes(service) ? 'Remove' : 'Add' }}
                              </button>
                          </div>
                      </div>
  
                  </div>
              </div>
          </div>
      </div>
  
      <div class="Price-Summary">
          <div class="price-division">
              <h2 class="price-summary-title">Price Summary </h2>
              <ol>
                  <li v-for="service in selectedServices" :key="service.ServiceName" class="service-list-item">
                      <span class="service-name">{{ service.ServiceName }}</span>
                      <span class="Rateline">₹{{ service.ServiceCost }}</span>
                  </li>
              </ol>
              <p class="subtotal custom-summary">Subtotal: ₹{{ totalPrice }}</p>
              <p class="tax custom-summary">Tax (10%): ₹{{ (totalPrice * 0.1).toFixed(2) }}</p>
              <h4 class="order-total custom-summary">Order Total: ₹{{ (totalPrice + (totalPrice * 0.1)).toFixed(2) }}</h4>
              <div>
                  <button v-if="totalPrice > 0" @click="handleOrder" class="order-button">Complete Order</button>
              </div>
          </div>
      </div>
  
  </div>
  
  <div>
      <FaqDiv />
  </div>
  
  <div v-if="showPopup" class="Popup">
      <div class="Popup-content">
          <div id="Popup-heading">Login</div>
          <LoginPageVue />
          <button id="Popup-button" @click="closePopup">Close</button>
      </div>
  </div>
</template>

<script>
    import '@/assets/StyleSheet/OrderPage/CompleteOrder.css'
    import FaqDiv from '@/components/Homepage/FaqBilling.vue'
    import axios from 'axios'
    import isUserLoggedIn from '@/components/Homepage/LoginCheck.vue'
    import { ref } from 'vue'
    import LoginPageVue from '@/components/Homepage/LoginPage.vue'
    import Popup from '@/components/RepairService/PopUp.vue'

export default {
name: 'SmartWatch Services',
components: {
  LoginPageVue,
  Popup,
  FaqDiv,
  },
  data() {
    return {
            showModal: false,
            isVisible: ref(false),
            showPopup: false,
            show: false,
            email: '',
            password: '',
            totalPrice: 0,
            selectedServices: [],
            services: [],
            OrderNumber: this.GenerateOrderNumber(8),
            InvoiceNumber: this.GenerateInvoiceNumber(7),
        };
  },
    mounted() {
    this.fetchData();
  },
  methods: {
    getImageUrl(pic) {
      return require(`@/assets/SmartWatch_img/${pic}`);
    },
    getServiceImageUrl(pic) {
      return require(`@/assets/Repair_img/${pic}`);
    },
    fetchData() {
      axios.get('http://localhost:5047/api/device/GetPhoneRepairDetails?DeviceCode='+this.$route.query.DeviceCode)
        .then((response) => {
          this.services = response.data;
        })
        .catch((error) => {
          debugger
          console.error('Error fetching data:', error);
        });
    },

    toggleService(service) {
      const selectedService = this.services.find((s) => s.ServiceName === service.ServiceName);
      selectedService.isselected = !selectedService.isselected;
      if (selectedService.isselected) {
        this.totalPrice += selectedService.ServiceCost;
        this.selectedServices.push(selectedService);
      } else {
        this.totalPrice -= selectedService.ServiceCost;
        const index = this.selectedServices.indexOf(selectedService);
        if (index !== -1) {
          this.selectedServices.splice(index, 1);
        }
      }
    },
    openPopup() {
      this.showPopup = true;
    },
    closePopup() {
      this.showPopup = false;
    },
    sendDataToApi() {
            const repairData = [];

            this.selectedServices.forEach(element => {
                repairData.push({
                    ServiceID: element.ServiceCode,
                    ServiceCost: element.ServiceCost
                })
            });

            const dataToSend = {
                DeviceCode: this.selectedServices[0].DeviceCode,
                UserEmail: sessionStorage.getItem("Email"),
                SubtotalCost: this.totalPrice + '',
                Tax: (this.totalPrice * 0.1).toFixed(2),
                TotalCost: (this.totalPrice + (this.totalPrice * 0.1)).toFixed(2),
                InvoiceNumber: this.InvoiceNumber,
                RecieptVoucherNumber: this.OrderNumber,
                data: repairData
            };

            let headers = {
                'Content-Type': 'application/json;charset=utf-8'
            };
            console.log(dataToSend.InvoiceNumber);
            console.log(dataToSend.RecieptVoucherNumber);
            const apiUrl = 'http://localhost:5047/api/device/SetUserDeviceRepairDetails';
            axios
                .post(apiUrl, dataToSend, {
                    headers
                })
                .then(response => {
                    console.log('Response from API:', response.data);
                    this.$router.push({
                        path: '/TrackingPage',
                        query: {
                            DeviceCode: this.selectedServices[0].DeviceCode
                        },
                    });

                })
                .catch(error => {
                    console.error('Error sending data to API:', error);
                });
        },
        handleOrder() {
            if (isUserLoggedIn.data().isUserLoggedIn) {
                console.log(this.selectedServices);
                alert('Order Successful');
                this.sendDataToApi();
            } else {
                alert('not loggedIn')
                this.showPopup = true;
            }
        },
        showAlert() {
            alert('Order successful');
        },

        GenerateOrderNumber(length) {
            const charset = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
            let result = '';
            for (let i = 0; i < length; i++) {
                const randomIndex = Math.floor(Math.random() * charset.length);
                result += charset.charAt(randomIndex);
            }
            return result;
        },
        GenerateInvoiceNumber(length) {
            const charset = '0123456789';
            let result = '';
            for (let i = 0; i < length; i++) {
                const randomIndex = Math.floor(Math.random() * charset.length);
                result += charset.charAt(randomIndex);
            }
            return result;
        }

    },
};
</script>






