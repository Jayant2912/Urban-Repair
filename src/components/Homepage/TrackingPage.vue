<template>
  <div class="Tracking-Page-Container">
      <div>
        <h1 style="margin-left: 8px; margin-right:8px">Thanks for your Order,<span class="change-color">{{ userName }}</span>!</h1>
      </div>
      <div>
        <h1 style="margin-left: 8px; margin-right:8px; color:green ">Your device will be picked up with in 12-24 hours.</h1>
      </div>
      <div id="Order-Details">
        <p>Invoice Number: <span style="color: green;">{{ this.InvoiceNumber }}</span></p>
      </div>
      <div id="Order-Details">
        <p>Invoice Date: <span style="color: green;">{{ formatDate(this.InvoiceDate)  }}</span></p>
      </div>
      <div id="Order-Details">
        <p>Receipt Voucher: <span style="color: green;">{{ this.OrderNumber }}</span></p>
      </div>
      <div>
        <h1 style="margin-left:5px;">TOTAL PAID:<span style="color: green;">&#8377;{{ this.TotalCost }}</span></h1>
      </div>
  </div>
  </template>
  
  <script>
  import '@/assets/StyleSheet/HomePage/bottom-division.css'
   import axios from 'axios'
   import dayjs from 'dayjs';
  export default {
    data() {
      return {
        showModal: false,
        OrderNumber: '',
        InvoiceDate:'',
        InvoiceNumber: '',
        TotalCost:'',
        Device:[],
        isUserLoggedIn: sessionStorage.getItem('IsVerified') ? 'true' : 'false',
        userName: sessionStorage.getItem('UserName') || 'Guest'
      };
    },
    watch: {
      $route(to, from) {
        this.isUserLoggedIn = sessionStorage.getItem('IsVerified') ? 'true' : 'false';
        this.userName = sessionStorage.getItem('UserName') || 'Guest';
      }
    },
    methods: {
      formatDate(dateString) {
            const date = dayjs(dateString);
                // Then specify how you want your dates to be formatted
            return date.format('dddd MMMM D, YYYY');
        },
      fetchData() {
      axios.get('http://localhost:5047/api/device/GetUserDeviceRepairDetails?DeviceCode='+this.$route.query.DeviceCode+'&&EmailId='+sessionStorage.getItem("Email"))
        .then((response) => {
          this.Devices = response.data[0];
          this.InvoiceNumber=this.Devices.InvoiceNumber;
          this.OrderNumber=this.Devices.RecieptVoucherNumber;
          this.InvoiceDate = this.Devices.CreatedDate;
          this.TotalCost = Number(this.Devices.TotalCost) +Number(this.Devices.TotalCost*0.1) ;
        })
        .catch((error) => {
          console.error('Error fetching data:', error);
        });
      },
    },
    created() {
      this.fetchData();     
      console.log(this.TotalCost);
    },
  };
  </script>

  <style>
  .Tracking-Page-Container{
    text-align: start;
    margin-left: 17px;
    border: 2px solid;
    display: inline-block;
    margin: 10px;
    background-color: azure;
    font-size: 20px;
  }
  #Order-Details{
    margin: 10px;
    border-top: solid;
  }
  </style>