<template>
  <v-container grid-list-xs>
    <v-card>
      <v-card-title>
        Usuários
        <div class="flex-grow-1"></div>
        <v-text-field v-model="search" label="Buscar" append-icon="search" single-line hide-details></v-text-field>
      </v-card-title>
      <v-data-table
        :search="search"
        :headers="headers"
        :items="users"
        :items-per-page="10"
        class="elevation-1"
      ></v-data-table>
    </v-card>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    search: "",
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
      return responseData.data;
    }
  },
  async created() {
    this.users = await this.getAllUsers();
  }
};
</script>
