<template>
  <div>
    <v-navigation-drawer
      v-model="drawer"
      app
      temporary
    >
      <v-list dense>
        <!--
          <v-switch v-model="$vuetify.theme.dark" label="dark">dark</v-switch>
        -->
        <v-list-item link :to="{path: '/'}">
          <v-list-item-action>
            <v-icon>mdi-home</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Index</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link :to="{path: '/consulta'}">
          <v-list-item-action>
            <v-icon>mdi-calendar-alert</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Consultas</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-home</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Lista de exames</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link :to="{path: '/agendar'}">
          <v-list-item-action>
            <v-icon>mdi-calendar-month</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Agendamento</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link :to="{path: '/contato'}">
          <v-list-item-action>
            <v-icon>mdi-contact-mail</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Contato</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar
      app
      color="indigo"
      dark
    >
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title>Prontuário</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-menu offset-y>
        <template v-slot:activator="{ on }">
          <v-btn 
            dark
            icon 
            v-on="on"
          >          
            <v-icon>
              mdi-login-variant
            </v-icon>
          </v-btn>
        </template>
        <v-list>
          <v-list-item link :to="{path: '/login'}">
            <v-list-item-title>Fazer Login</v-list-item-title>
          </v-list-item>
          <v-divider></v-divider>
          <v-list-item link :to="{path: '/cadastro'}">
            <v-list-item-title>Cadastrar</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
    </v-app-bar>

  </div>
</template>

<script>
  export default {
    name: 'Header',
    props: {
      source: String,
    },

    data: () => ({
      drawer: null,
    }),
  }
</script>