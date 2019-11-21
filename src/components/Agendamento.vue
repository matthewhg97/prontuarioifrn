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
                <v-toolbar-title>Agendar consulta</v-toolbar-title>
                <v-spacer />
            </v-toolbar>            
            <v-card-text>
                <v-form ref="form" v-model="valid" lazy-validation>
                    <v-text-field v-model="name" :counter="10" :rules="nameRules" label="Nome do paciente" required></v-text-field>

                    <v-text-field v-model="cpf" :rules="cpfRules" label="CPF" required></v-text-field>

                    <v-select
                        v-model="select"
                        :items="items"
                        :rules="[v => !!v || 'Precisa selecionar um motivo.']"
                        label="Motivo"
                        required
                    ></v-select>

                    <v-text-field v-model="detalhes" :rules="detalhesRules" label="Mais detalhes" textarea></v-text-field>

                    <v-btn :disabled="!valid" color="success" class="mr-4" @click="validate">Agendar</v-btn>

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
    name: 'Agendamento',
    data: () => ({
        valid: true,
        name: "",
        nameRules: [
            v => !!v || "É obrigatório colocar o nome",
            v => (v && v.length <= 32) || "O nome não pode ter mais de 32 caracteres."
        ],
        cpf: "",
        cpfRules: [
            v => !!v || "O CPF é obrigatório",
        ],
        detalhes: "",
        detalhesRules: [v => !!v || "É obrigatório colocar os detalhes."],
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

}
</script>

<style>

</style>