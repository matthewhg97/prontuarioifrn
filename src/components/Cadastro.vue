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
                <v-toolbar-title>Faça seu cadastro</v-toolbar-title>
                <v-spacer />
            </v-toolbar>            
            <v-card-text>
                <v-form ref="form" v-model="valid" lazy-validation>
                    <v-text-field v-model="name" :counter="10" :rules="nameRules" label="Nome" required></v-text-field>

                    <v-text-field v-model="username" :counter="10" :rules="usernameRules" label="Nome de usuário" required></v-text-field>

                    <v-text-field v-model="cpf" :rules="cpfRules" label="CPF" required></v-text-field>

                    <v-radio-group v-model="radio" v-for="item in items" v-bind:key="item.id">
                        <v-radio
                            :label="item.tipo"
                            :rules="[v => !!v || 'Precisa selecionar o tipo de usuário.']"
                            required
                            :value="item.id"
                        ></v-radio>
                    </v-radio-group>

                    <div v-if="radio == 2">
                        <v-text-field v-model="crm" :rules="crmRules" label="CRM" required></v-text-field>

                        <v-text-field v-model="especializacao" :rules="especializacaoRules" label="Especialização" required></v-text-field>
                    </div>

                    <v-btn :disabled="!valid" color="success" class="mr-4" @click="validate">Cadastrar</v-btn>

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
    name: 'Cadastro',
    data: () => ({
        valid: true,
        name: "",
        nameRules: [
            v => !!v || "É obrigatório colocar o nome",
            v => (v && v.length <= 32) || "O nome não pode ter mais de 32 caracteres."
        ],
        username: "",
        usernameRules: [v => !!v || "É obrigatório colocar o nome de usuário."],
        cpf: "",
        cpfRules: [
            v => !!v || "O CPF é obrigatório",
        ],
        crm: "",
        crmRules: [
            v => !!v || "O CRM é obrigatório",
        ],
        especializacao: "",
        especializacaoRules: [v => !!v || "É obrigatório colocar sua especialização."],
        radio: 0,
        items: [
            {
                id: 1,
                tipo: "Recepcionista" 
            },
            {
                id: 2,
                tipo: "Médico"
            }
        ],
        checkbox: false
    }),

    computed: {
                
    },

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