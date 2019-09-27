<template>
  <v-container grid-list-xs>
    <v-layout row wrap>
      <pre>{{users}}</pre>
      <v-flex mt-5 offset-xs2 xs8>
        <v-data-table :headers="headers" :items="users" :items-per-page="10" class="elevation-1"></v-data-table>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    headers: [
      { text: "#", value: "id" },
      { text: "Nome", value: "name" },
      { text: "email", value: "apartament" }
    ],
    users: []
  }),
  methods: {
    async getAllUsers() {
      const responseData = await this.$http.get(
        "https://localhost:5001/api/user"
      );
      return responseData.body;
    }
  },
  async created() {
    this.users = await this.getAllUsers();
  }
};
</script>
