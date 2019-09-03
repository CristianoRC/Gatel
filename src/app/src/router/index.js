import Vue from "vue";
import Router from "vue-router";
import homePage from "@/components/Home"
import about from "@/components/About"
import login from "@/components/authentication/Login"


Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      name: "home",
      component: homePage,
    },
    {
      path: '/about',
      name: 'about',
      component: about
    },
    {
      path: '/login',
      name: 'login',
      component: login
    }
  ]
});
