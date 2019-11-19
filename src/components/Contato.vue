<template>
  <v-app id="inspire">
    <v-row justify="center">
      <v-col cols="12" sm="10" md="8" lg="6">
        <v-card>
            <v-toolbar
              color="primary"
              dark
              flat
            >
                <v-toolbar-title>Entre em contato conosco!</v-toolbar-title>
                <v-spacer />
            </v-toolbar>            
            <v-card-text>
                <v-form ref="form" v-model="valid" lazy-validation>
                    <v-text-field v-model="name" :counter="10" :rules="nameRules" label="Nome" required></v-text-field>

                    <v-text-field v-model="email" :rules="emailRules" label="E-mail" required></v-text-field>

                    <v-select
                        v-model="select"
                        :items="items"
                        :rules="[v => !!v || 'Precisa selecionar um assunto.']"
                        label="Assunto"
                        required
                    ></v-select>

                    <v-text-field v-model="conteudo" :rules="conteudoRules" label="Conteúdo" textarea></v-text-field>

                    <v-btn :disabled="!valid" color="success" class="mr-4" @click="validate">Confirmar</v-btn>

                    <v-btn color="error" class="mr-4" @click="reset">Limpar</v-btn>
                </v-form>
            </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-app>
</template>

<script>
export default {
  name: "Contato",
  data: () => ({
    valid: true,
    name: "",
    nameRules: [
      v => !!v || "É obrigatório colocar o nome",
      v => (v && v.length <= 10) || "O nome não pode ter mais de 10 caracteres."
    ],
    email: "",
    emailRules: [
      v => !!v || "E-mail necessário",
      v => /.+@.+\..+/.test(v) || "E-mail precisa ser válido."
    ],
    conteudo: "",
    conteudoRules: [v => !!v || "É obrigatório colocar conteúdo"],
    select: null,
    items: ["Item 1", "Item 2", "Item 3", "Item 4"],
    checkbox: false
  }),

  methods: {
    validate() {
      if (this.$refs.form.validate()) {
        this.snackbar = true;
      }
    },
    reset() {
      this.$refs.form.reset();
    },
    resetValidation() {
      this.$refs.form.resetValidation();
    }
  }
};
</script>

<style>
</style>