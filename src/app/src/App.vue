<template>
  <v-app app>
    <v-app-bar v-if="$route.name !== 'login'" app color="primary" dark>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <v-toolbar-title>Gatel</v-toolbar-title>
      <div class="flex-grow-1"></div>
      <v-btn icon>
        <v-icon>mdi-dots-vertical</v-icon>
      </v-btn>
    </v-app-bar>
    <v-content>
      <v-navigation-drawer v-model="drawer" app absolute bottom temporary>
        <v-list nav dense>
          <v-list-item-group
            v-for="page in pages"
            :key="page"
            active-class="deep-purple--text text--accent-4"
          >
            <v-list-item @click="to(page.name)">
              <v-list-item-title>{{page.title}}</v-list-item-title>
            </v-list-item>
          </v-list-item-group>
        </v-list>
      </v-navigation-drawer>

      <router-view></router-view>
    </v-content>
  </v-app>
</template>

<script>
export default {
  name: "Gatel",
  data: () => ({
    drawer: false,
    pages: [
      { title: "Home", name: "home" },
      { title: "Usuários", name: "users" },
      { title: "Sobre", name: "about" }
    ]
  }),
  methods: {
    to(route) {
      this.$router.push({ name: route });
    }
  }
};
</script>
