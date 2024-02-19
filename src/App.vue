<template>
<div class="header-1">
    <div class="header-2-repair-center">
      <span class="Home_text-Route" onclick="window.location.href = '/'">Home</span>
    </div>
    <div>
        <span class="User-details-message">Welcome: </span>
        <span class="User-details-message">{{ userName }}</span>
    </div>
    <div>
        <button v-if="isUserLoggedIn=='false'" class="header-1-signup-button" onclick="window.location.href ='/Signup'">Signup</button>
        <button v-if="isUserLoggedIn === 'true'" class="header-1-signup-button" onclick="window.location.href ='/Status'">Status</button>
    </div>
    <div>
        <button v-if="isUserLoggedIn=='false'" class="header-1-login-button" onclick="window.location.href ='/login' ">Login</button>
        <button v-if="isUserLoggedIn=='true'" class="header-1-login-button" @click="logout">Logout</button>
    </div>
</div>
<router-view />
<div class="bottom-division">
  <div class="company-details">
  <h3>Company Details</h3>
  <p><strong>Name:</strong> Delhi Repairs</p>
  <p><strong>Address:</strong>Vivek Vihar,New Delhi-110095</p>
  <p><strong>Category:</strong> Appliance Repair Services</p>
  <p><strong>Phone:</strong> 999988881111</p>
  <p><strong>Hours:</strong> Monday - Sunday, 8:00 AM - 9:00 PM</p>
  <p><strong>Website:</strong> <a href="/" target="_blank">DelhiRepair.com</a></p>
  </div>
  <div class="company-location">
    <h3>View us on map</h3>
    <div class="image-position">
    <img src="@/assets/HomeImages/Maps_Dark.png" class="map-image">
    <div class="map-link"><a href="https://goo.gl/maps/xieDxS1Mc6Tp4XLz7" target="_blank">View-Larger</a></div>
  </div>
  </div>

  <div class="connections-follow">
    <h3>Follow Us</h3>
    <div class="follow-icons">
      <div class="social-media-icons">
        <a href="https://www.facebook.com" target="_blank" class="fa-icon-link">
          <font-awesome-icon :icon="{ prefix: 'fab', iconName: 'facebook'}" class="fa-icon-class" style="color: #1434A4;"></font-awesome-icon>
        </a>
        <a href="https://www.instagram.com" target="_blank" class="fa-icon-link">
          <font-awesome-icon :icon="{ prefix: 'fab', iconName: 'instagram'}" class="fa-icon-class" style="color: 	#FF69B4;"></font-awesome-icon>
        </a>
        <a href="https://www.twitter.com" target="_blank" class="fa-icon-link">
          <font-awesome-icon :icon="{ prefix: 'fab', iconName: 'twitter'}" class="fa-icon-class" style="color: #0096FF;"></font-awesome-icon>
        </a>
        <a href="https://www.youtube.com" target="_blank" class="fa-icon-link">
          <font-awesome-icon :icon="{ prefix: 'fab', iconName: 'youtube'}" class="fa-icon-class" style="color: red;"></font-awesome-icon>
        </a>
        <a href="https://www.medium.com" target="_blank" class="fa-icon-link">
          <font-awesome-icon :icon="{ prefix: 'fab', iconName: 'medium'}" class="fa-icon-class"  style="color: white; background-color=black;"></font-awesome-icon>
        </a>
        <a href="https://www.telegram.org" target="_blank" class="fa-icon-link">
          <font-awesome-icon :icon="{ prefix: 'fab', iconName: 'telegram'}" class="fa-icon-class" style="color: #89CFF0;"></font-awesome-icon>
        </a>
        <a href="https://www.whatsapp.com" target="_blank" class="fa-icon-link">
          <font-awesome-icon :icon="{ prefix: 'fab', iconName: 'whatsapp'}" class="fa-icon-class" style="color: green;"></font-awesome-icon>
        </a>
        <a href="https://www.linkedin.com" target="_blank" class="fa-icon-link">
          <font-awesome-icon :icon="{ prefix: 'fab', iconName: 'linkedin'}" class="fa-icon-class" style="color: #1434A4;"></font-awesome-icon>
        </a>
      </div>
    </div>
    
    </div>
</div>
</template>

<style lang="scss">
#app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    background-color: aliceblue;
}
nav {
    padding: 30px;
    a {
        font-weight: bold;
        color: #2c3e50;
        &.router-link-exact-active {
            color: #42b983;
        }
    }
}
</style>

<script>
import '@/assets/StyleSheet/HomePage/home-page-layout.css'
import '@/assets/StyleSheet/HomePage/steps.css'
import '@/assets/StyleSheet/HomePage/services.css'
import '@/assets/StyleSheet/HomePage/faqs-division.css'
import '@/assets/StyleSheet/HomePage/bottom-division.css'
import Popup from '@/components/RepairService/PopUp.vue'
export default {
  components: {
  Popup,
  },
    data() {
        return{
          showModal: false,
            selectedCategory: 'Home', 
            isUserLoggedIn: (sessionStorage.getItem('IsVerified') ? 'true' : 'false'),
            userName: (sessionStorage.getItem('UserName') ? sessionStorage.getItem('UserName') : 'Guest')
        }
    },
    watch: {
        $route(to, from) {
            this.isUserLoggedIn = (sessionStorage.getItem('IsVerified') ? 'true' : 'false'),
                this.userName = (sessionStorage.getItem('UserName') ? sessionStorage.getItem('UserName') : 'Guest')
        }
    },
    methods: {
        logout() {
            sessionStorage.removeItem("UserName");
            sessionStorage.removeItem("Email");
            sessionStorage.removeItem("IsVerified");
            window.location.reload();
        },
    handleChange() {
      const selectedValue = this.selectedCategory;
      const categoryToRouteMap = {
        'Home':'/',
        'Phones': '/Phones',
        'Smart Tv': '/SmartTv',
        'Smart Watch': '/SmartWatch',
        'Tablets': '/Tablets',
        'Laptops': '/Laptops',
        'Refrigerators': '/Refrigerators',
        'Air conditioners': '/Air_conditioner',
        'Washing Machines': '/WashingMachine',
      };
      const route = categoryToRouteMap[selectedValue];
      if (route) {
        this.$router.push(route); 
      }
    },
  },
};
</script>
