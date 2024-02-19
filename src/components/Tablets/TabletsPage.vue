<template>
  <div class="Tablet-Page-header">
    <div style="display: flex; position:relative; top:100px;">
      <img class="Tablet-Page-header-image1" src="@/assets/page1_img/repairman_new.png">
    <div class="Tablet-page-head-div">
      <div class="Tablet-Page-header-heading">
      Your Trusted Partner in Tablet Restoration
    </div>
    <div style="display:inline-block">
    <div id="filler-text"><span>&#9733;</span> Unlocking Possibilities</div>
      <div id="filler-text"><span>&#9733;</span> Breathe Life Back In</div>
      <div id="filler-text"><span>&#9733;</span> Repair Perfected</div>
    </div>
  </div>
  </div>
  <img class="Tablet-Page-header-image2" src="@/assets/page1_img/tablet_repair.jpg">
  </div>


<div class="Tablet-Page-container">
    <div class="Tablet-Main-content">
       
      <div style="font-size:44px; text-align:start; font-weight:600;">
        Select Brand
      </div>

        <div class="Tablet-Templates">
            <div class="Tablet-Company-Name-Container" v-for="(brand, index) in brands" :key="brand.ID">
                <div class="Tablet-Template-Images-Container" @click="handlesubmit(brand.BrandName,brand.ID,brand.DeviceType)">
                    <img class="Tablet-Company-Image" :src="getImageUrl(brand.BrandImage)" :alt="brand.BrandName">
                    <div class="Tablet-Company-Name">{{ brand.BrandName }}</div>
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
import '@/assets/StyleSheet/SericesPages/TabletsPage.css'
export default {
  components : {
    whyus,
  },
  name: 'Tablet Page',
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
    axios.get('http://localhost:5047/api/device/GetAllBrands?type=Tablets')
      .then((response) => {
        this.brands = response.data;
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
      });
  },
  handlesubmit(selectedValue,id,dType) {
    this.$router.push({
                  path: `/Tablet_Brands`,
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
