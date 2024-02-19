<template>
  <div class="Model-Heading">
    Select Model
  </div>
  <div class="Main-Body-Template">
    <div class="Model-Container" v-for="(Device, index) in Devices" :key="Device.Image" @click="navigateToPhoneServices(Device.DeviceCode)">
        <img class="Templates-Model-Image" :src="getImageUrl(Device.Image,Device.ImgPath)" :alt="Device.Image">
        <div class="Template-Model-Name">{{ Device.DeviceName }}</div>
      </div>
  </div>
  <div>
    <ModelDetailsPage/>
  </div>
</template>
    
<script>
import ModelDetailsPage from '@/components/Homepage/ModelPageComp.vue'
import '@/assets/StyleSheet/ModelSelect/ModelPage.css'
import axios from 'axios';
export default{
  components:{
    ModelDetailsPage,
  },
    name:'Tablet Brands',
data(){
    return{
      Devices: [],
    };
},
mounted() {
this.fetchData();
},
methods:{
    fetchData() {
    axios.get('http://localhost:5047/api/device/GetAllDevices?id='+this.$route.query.id+'&&dType='+this.$route.query.dType)
    .then((response) => {
      this.Devices = response.data;
      
    })
    .catch((error) => {
      console.error('Error fetching data:', error);
    });
},
    getImageUrl(pic,ImgPath){
        return require(`@/assets/${ImgPath}/${pic}`);
    },
    navigateToPhoneServices(DeviceCode) {
            this.$router.push({
                path: '/Tablet_Services',
                query: {
                  DeviceCode: DeviceCode,
                },
            });
        },
    },
}
</script>
    
