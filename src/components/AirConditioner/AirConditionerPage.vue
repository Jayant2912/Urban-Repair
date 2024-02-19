<template>
  <div class="Ac-Page-header">
    <div style="display: flex; position:relative; top:100px;">
      <img class="Ac-Page-header-image1" src="@/assets/page1_img/mechanic.png">
    <div class="Ac-page-head-div">
      <div class="Ac-Page-header-heading">
      Your Trusted Partner in Air Conditioner Restoration
    </div>
    <div style="display:inline-block">
    <div id="filler-text"><span>&#9733;</span> Unlocking Possibilities</div>
      <div id="filler-text"><span>&#9733;</span> Breathe Life Back In</div>
      <div id="filler-text"><span>&#9733;</span> Repair Perfected</div>
    </div>
  </div>
  </div>
  <img class="Ac-Page-header-image2" src="@/assets/page1_img/airconditioner_repair.jpg">
  </div>
  
  

  <div class="Ac-Page-container">
    <div class="Ac-Main-content">
      
      <div style="font-size:44px; text-align:start; font-weight:600;">
        Select Brand
      </div>

      <div class="Ac-Templates">
        <div class="Ac-Company-Name-Container" v-for="(brand, index) in brands" :key="brand.ID">
          <div class="Ac-Template-Images-Container" @click="handlesubmit(brand.BrandName,brand.ID,brand.DeviceType)">
            <img class="Ac-Company-Image" :src="getImageUrl(brand.BrandImage)" :alt="brand.BrandName">
            <div class="Ac-Company-Name">{{ brand.BrandName }}</div>
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
  import '@/assets/StyleSheet/SericesPages/AirConditionerPage.css'
  import axios from 'axios'
  export default {
    components : {
    whyus,
  },
  name: 'Air Conditioner Page',
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
      axios.get('http://localhost:5047/api/device/GetAllBrands?type=AirConditioner')
        .then((response) => {
          this.brands = response.data;
        })
        .catch((error) => {
          console.error('Error fetching data:', error);
        });
    },
    handlesubmit(selectedValue,id,dType) {
      this.$router.push({
                    path: `/AC_Brands`,
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