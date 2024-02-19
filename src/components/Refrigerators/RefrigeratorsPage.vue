<template>
  <div class="Refrigerator-Page-header">
    <div style="display: flex; position:relative; top:100px;">
      <img class="Refrigerator-Page-header-image1" src="@/assets/page1_img/mechanic.png">
    <div class="Refrigerator-page-head-div">
      <div class="Refrigerator-Page-header-heading">
      Your Trusted Partner in Refrigerator Restoration
    </div>
    <div style="display:inline-block">
    <div id="filler-text"><span>&#9733;</span> Unlocking Possibilities</div>
      <div id="filler-text"><span>&#9733;</span> Breathe Life Back In</div>
      <div id="filler-text"><span>&#9733;</span> Repair Perfected</div>
    </div>
  </div>
  </div>
  <img class="Refrigerator-Page-header-image2" src="@/assets/page1_img/refrigerator_repair.jpg">
  </div>


  <div class="Refrigerator-Page-container">
    <div class="Refrigerator-Main-content">
    
      <div style="font-size:44px; text-align:start; font-weight:600;">
        Select Brand
      </div>

      <div class="Refrigerator-Templates">
        <div class="Refrigerator-Company-Name-Container" v-for="(brand, index) in brands" :key="brand.ID">
          <div class="Refrigerator-Template-Images-Container" @click="handlesubmit(brand.BrandName,brand.ID,brand.DeviceType)">
            <img class="Refrigerator-Company-Image" :src="getImageUrl(brand.BrandImage)" :alt="brand.BrandName">
            <div class="Refrigerator-Company-Name">{{ brand.BrandName }}</div>
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
import axios from 'axios';
import whyus from '@/components/Homepage/WhyUs.vue'
import '@/assets/StyleSheet/SericesPages/RefrigeratorPage.css'
export default {
  components : {
    whyus,
  },
  name: 'Refrigerator Page',
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
    axios.get('http://localhost:5047/api/device/GetAllBrands?type=Refrigerators')
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
                  path: `/Refrigerator_Brands`,
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

  