 <template>
  <div class="phone-Page-header">
    <div style="display: flex; position:relative; top:100px;">
      <img class="phone-Page-header-image1" src="@/assets/page1_img/repairman_new.png">
    <div class="phone-head-div">
      <div class="phone-Page-header-heading">
      Your Trusted Partner in Phone Restoration
    </div>
    <div style="display:inline-block">
    <div id="filler-text"><span>&#9733;</span> Unlocking Possibilities</div>
      <div id="filler-text"><span>&#9733;</span> Breathe Life Back In</div>
      <div id="filler-text"><span>&#9733;</span> Repair Perfected</div>
    </div>
  </div>
  </div>
  <img class="phone-Page-header-image2" src="@/assets/page1_img/phone_repair.jpg">
  </div>

  <div class="Phone-Page-container">
    <div class="Phone-Main-content">

      <div style="font-size:44px; text-align:start; font-weight:600;">
          Select Brand
        </div>

      <div class="Phone-Templates">
        <div class="Phone-Company-Name-Container" v-for="(brand, index) in brands" :key="brand.ID">
          <div class="Phone-Template-Images-Container" @click="handlesubmit(brand.BrandName,brand.ID,brand.DeviceType)">
            <img class="Phone-Company-Image" :src="getImageUrl(brand.BrandImage)" :alt="brand.BrandName">
            <div class="Phone-Company-Name">{{ brand.BrandName }}</div>
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
import '@/assets/StyleSheet/SericesPages/PhonePage.css'
import axios from 'axios'

export default {
  components : {
    whyus,
  },
  name: 'Phones Page',
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
      axios.get('http://localhost:5047/api/device/GetAllBrands?type=Phone')
        .then((response) => {
          this.brands = response.data;
        })
        .catch((error) => {
          console.error('Error fetching data:', error);
        });
    },
    handlesubmit(selectedValue,id,dType) {
      this.$router.push({
                    path: `/Phone_Brands`,
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

 



