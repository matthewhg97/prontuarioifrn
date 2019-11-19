<template>
  <v-app>
    <Header></Header>
    <v-content>
      <v-container fluid>
        <v-row>
          <v-col class="text-center">
            <router-view></router-view>
          </v-col>
        </v-row>
      </v-container>
    </v-content>
    <Footer></Footer>
  </v-app>
</template>

<script>
import Header from './components/Header';
import Footer from './components/Footer';


export default {
  name: 'App',

  components: {
    Header,
    Footer,
  },
  props: {

  },

  data: () => ({

  }),
};
</script>
