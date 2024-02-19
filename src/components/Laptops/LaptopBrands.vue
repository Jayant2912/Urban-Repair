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
    name:'Laptop Brands',
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
                path: '/Laptop_Services',
                query: {
                  DeviceCode: DeviceCode,
                },
            });
        },
    },
}
</script>
    
<style>
.image-size{
    display: flex;
    flex-wrap: wrap;
    justify-content: space-between;
    padding-left: 30px;
    padding-right: 30px;

}
.phone-templates-image{
  display: grid;
  width: 180px;
  height: 230px;
  padding: 10px 10px 10px 10px;
  
}
.imgcontainer{
    box-shadow: rgba(50, 50, 93, 0.25) 0px 50px 100px -20px, rgba(0, 0, 0, 0.3) 0px 30px 60px -30px, rgba(10, 37, 64, 0.35) 0px -2px 6px 0px inset;
    border-radius: 15px;
    width: calc(25% - 90px);
}
</style>