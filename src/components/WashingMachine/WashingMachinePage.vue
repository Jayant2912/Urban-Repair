<template>
  <div class="WashingMachine-Page-header">
    <div style="display: flex; position:relative; top:100px;">
      <img class="WashingMachine-Page-header-image1" src="@/assets/page1_img/mechanic.png">
    <div class="WashingMachine-page-head-div">
      <div class="WashingMachine-Page-header-heading">
      Your Trusted Partner in Washing Machine Restoration
    </div>
    <div style="display:inline-block">
    <div id="filler-text"><span>&#9733;</span> Unlocking Possibilities</div>
      <div id="filler-text"><span>&#9733;</span> Breathe Life Back In</div>
      <div id="filler-text"><span>&#9733;</span> Repair Perfected</div>
    </div>
  </div>
  </div>
  <img class="WashingMachine-Page-header-image2" src="@/assets/page1_img/washingmachine_repair.jpg">
  </div>
  
 

  <div class="WashingMachine-Page-container">
    <div class="WashingMachine-Main-content">
      
      <div style="font-size:44px; text-align:start; font-weight:600;">
        Select Brand
      </div>

      <div class="WashingMachine-Templates">
        <div class="WashingMachine-Company-Name-Container" v-for="(brand, index) in brands" :key="brand.ID">
          <div class="WashingMachine-Template-Images-Container" @click="handlesubmit(brand.BrandName,brand.ID,brand.DeviceType)">
            <img class="WashingMachine-Company-Image" :src="getImageUrl(brand.BrandImage)" :alt="brand.BrandName">
            <div class="WashingMachine-Company-Name">{{ brand.BrandName }}</div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div>
    <whyus/>
  </div>
</template>

  <script>
  import '@/assets/StyleSheet/SericesPages/WashingMachinePage.css'
  import whyus from '@/components/Homepage/WhyUs.vue'
  import axios from 'axios';
  export default {
    components : {
    whyus,
  },
    name: 'WashingMachine Page',
   data() {
    return {
      brands: [],
    }; 
  },
  mounted() {
    this.fetchData();
  },
  methods: {
    fetchData() {
      axios.get('http://localhost:5047/api/device/GetAllBrands?type=WashingMachine')
        .then((response) => {
          this.brands = response.data;
        })
        .catch((error) => {
          console.error('Error fetching data:', error);
        });
    },
    handlesubmit(selectedValue,id,dType) {
      this.$router.push({
                    path: `/WashingMachine_Brands`,
                    query: {
                        id: id,
                        dType:dType
                    },
    })},
    getImageUrl(pic) {
      return require(`@/assets/services_logo/${pic}`);
    },
  },
};
</script>


  