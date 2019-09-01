<template>
  <v-container>
    <v-layout text-center wrap>
      <v-flex xs12>
        <pre>
          {{jsonData}}
        </pre>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    jsonData: ""
  }),
  created() {
    this.$http
      .get("https://jsonplaceholder.typicode.com/todos/1")
      .then(response => {
        this.jsonData = response.data;
      });
  }
};
</script>
