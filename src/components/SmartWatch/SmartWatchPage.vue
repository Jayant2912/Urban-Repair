<template>
  <div class="SmartWatch-Page-header">
    <div style="display: flex; position:relative; top:100px;">
      <img class="SmartWatch-Page-header-image1" src="@/assets/page1_img/repairman_new.png">
    <div class="SmartWatch-page-head-div">
      <div class="SmartWatch-Page-header-heading">
      Your Trusted Partner in SmartWatch Restoration
    </div>
    <div style="display:inline-block">
    <div id="filler-text"><span>&#9733;</span> Unlocking Possibilities</div>
      <div id="filler-text"><span>&#9733;</span> Breathe Life Back In</div>
      <div id="filler-text"><span>&#9733;</span> Repair Perfected</div>
    </div>
  </div>
  </div>
  <img class="SmartWatch-Page-header-image2" src="@/assets/page1_img/smartwatch_repair.jpg">
  </div>


  <div class="SmartWatch-Page-container">
    <div class="SmartWatch-Main-content">
     
      <div style="font-size:44px; text-align:start; font-weight:600;">
        Select Brand
      </div>

      <div class="SmartWatch-Templates">
        <div class="SmartWatch-Company-Name-Container" v-for="(brand, index) in brands" :key="brand.ID">
          <div class="SmartWatch-Template-Images-Container" @click="handlesubmit(brand.BrandName,brand.ID,brand.DeviceType)">
            <img class="SmartWatch-Company-Image" :src="getImageUrl(brand.BrandImage)" :alt="brand.BrandName">
            <div class="SmartWatch-Company-Name">{{ brand.BrandName }}</div>
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
  import whyus from '@/components/Homepage/WhyUs.vue'
  import '@/assets/StyleSheet/SericesPages/SmartWatchPage.css'
  import axios from 'axios';
  export default {
    components : {
    whyus,
  },
    name: 'SmartWatch Page',
   data() {
    return {
      brands: [],// Initialize an empty array to store the API response
    }; 
  },
  mounted() {
    // Fetch data from the API when the component is mounted
    this.fetchData();
  },
  methods: {
    fetchData() {
      // Make an API request to get the data
      axios.get('http://localhost:5047/api/device/GetAllBrands?type=SmartWatch')
        .then((response) => {
          this.brands = response.data;
        })
        .catch((error) => {
          console.error('Error fetching data:', error);
        });
    },
    handlesubmit(selectedValue,id,dType) {
      // Use the selectedValue directly to navigate based on brand name
      this.$router.push({
                    path: `/SmartWatch_Brands`,
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

  