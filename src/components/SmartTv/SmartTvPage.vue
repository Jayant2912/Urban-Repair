<template>
  <div class="SmartTv-Page-header">
    <div style="display: flex; position:relative; top:100px;">
      <img class="SmartTv-Page-header-image1" src="@/assets/page1_img/mechanic.png">
    <div class="SmartTv-page-head-div">
      <div class="SmartTv-Page-header-heading">
      Your Trusted Partner in SmartTv Restoration
    </div>
    <div style="display:inline-block">
    <div id="filler-text"><span>&#9733;</span> Unlocking Possibilities</div>
      <div id="filler-text"><span>&#9733;</span> Breathe Life Back In</div>
      <div id="filler-text"><span>&#9733;</span> Repair Perfected</div>
    </div>
  </div>
  </div>
  <img class="SmartTv-Page-header-image2" src="@/assets/page1_img/smartTv_repair.jpg">
  </div>


  <div class="SmartTv-Page-container">
    <div class="SmartTv-Main-content">
      
      <div style="font-size:44px; text-align:start; font-weight:600;">
          Select Brand
        </div>

      <div class="SmartTv-Templates">
        <div class="SmartTv-Company-Name-Container" v-for="(brand, index) in brands" :key="brand.ID">
          <div class="SmartTv-Template-Images-Container" @click="handlesubmit(brand.BrandName,brand.ID,brand.DeviceType)">
            <img class="SmartTv-Company-Image" :src="getImageUrl(brand.BrandImage)" :alt="brand.BrandName">
            <div class="SmartTv-Company-Name">{{ brand.BrandName }}</div>
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
import '@/assets/StyleSheet/SericesPages/SmartTvPage.css'
export default {
  components : {
    whyus,
  },
  name: 'SmartTv Page',
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
    axios.get('http://localhost:5047/api/device/GetAllBrands?type=SmartTv')
      .then((response) => {
        this.brands = response.data;
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
      });
  },
  handlesubmit(selectedValue,id,dType) {
    this.$router.push({
                  path: `/SmartTv_Brands`,
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
