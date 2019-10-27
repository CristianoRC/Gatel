import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify';
import vueRouter from 'vue-router'
import axios from "axios";
import router from './router'
import 'material-design-icons-iconfont/dist/material-design-icons.css'

Vue.config.productionTip = false
Vue.use(vueRouter);

// ====== prototype ====== //
Vue.prototype.$http = axios;


new Vue({
  vuetify,
  router,
  render: h => h(App)
}).$mount('#app')


