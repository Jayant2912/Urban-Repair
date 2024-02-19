import { createApp } from 'vue';
import App from './App.vue';
import './registerServiceWorker';
import router from './router';
import store from './store';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import { library } from '@fortawesome/fontawesome-svg-core'
import { faFacebook,faInstagram,faYoutube,faMedium,faTelegram,faWhatsapp,faLinkedin,faTwitter } from '@fortawesome/free-brands-svg-icons'
import {  } from '@fortawesome/free-brands-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { faInfoCircle } from '@fortawesome/free-solid-svg-icons';
global.jQuery = require('jquery');
var $ = global.jQuery;
window.$ = $

library.add(faFacebook,faInstagram,faYoutube,faMedium,faTelegram,faWhatsapp,faLinkedin,faTwitter,faInfoCircle)
createApp(App).use(store).use(router).component("font-awesome-icon", FontAwesomeIcon).mount("#app");
