<template >
  <div
    style="height: 100vh; background-size:cover; background-position:center"
    :style="{backgroundImage: `url(${backgroundImage})`}"
  >
    <v-container bg grid-list-md>
      <v-layout row wrap>
        <v-flex mt-3 offset-xs3 xs6>
          <v-card style="box-shadow: 0 20px 30px -16px rgba(9,9,16,.2)">
            <v-card-title primary-title class="justify-center">Gatel - Login</v-card-title>
            <v-card-text>
              <v-layout row wrap>
                <v-flex offset-xs2 xs8>
                  <v-text-field label="Login"></v-text-field>
                </v-flex>
                <v-flex offset-xs2 xs8>
                  <v-text-field type="password" label="Senha"></v-text-field>
                </v-flex>
                <v-flex offset-xs3 xs6>
                  <v-layout row wrap>
                    <v-flex xs6>
                      <v-btn flat block color="primary">cadastrar</v-btn>
                    </v-flex>
                    <v-flex xs6>
                      <v-btn flat block color="primary">Logar</v-btn>
                    </v-flex>
                  </v-layout>
                </v-flex>
              </v-layout>
            </v-card-text>
          </v-card>
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>


<script>
export default {
  data() {
    return {
      icon: require("@/assets/barrier.png"),
      backgroundImage: require("@/assets/2481003.jpg")
    };
  }
};
</script>

<style>
</style>