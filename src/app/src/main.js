import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify';
import vueRouter from 'vue-router'

Vue.config.productionTip = false
Vue.use(vueRouter);

new Vue({
  vuetify,
  render: h => h(App)
}).$mount('#app')
