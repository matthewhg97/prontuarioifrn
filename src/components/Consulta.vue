<template>
  <v-app id="inspire">
    <v-row justify="center">
      <v-col cols="12" sm="11" md="10">
        <v-data-table :headers="headers" :items="consultas" sort-by="tipo" class="elevation-1">
          <template v-slot:top>
            <v-toolbar flat color="white">
              <v-toolbar-title>Consultas</v-toolbar-title>
              <v-divider class="mx-4" inset vertical></v-divider>
              <v-spacer></v-spacer>
              <v-dialog v-model="dialog" max-width="500px">
                <template v-slot:activator="{ on }">
                  <v-btn color="primary" dark class="mb-2" v-on="on">Nova Consulta</v-btn>
                </template>
                <v-card>
                  <v-card-title>
                    <span class="headline">{{ formTitle }}</span>
                  </v-card-title>

                  <v-card-text>
                    <v-container>
                      <v-row>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field v-model="editedItem.namePaciente" label="Nome do paciente"></v-text-field>
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field v-model="editedItem.tipo" label="Tipo"></v-text-field>
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-dialog
                            ref="dialog"
                            v-model="menuData"
                            persistent
                            :return-value.sync="date"
                            width="300px"
                          >
                            <template v-slot:activator="{ on }">
                              <v-text-field 
                                :value="showData"
                                label="Data de agendamento"
                                hint="Formato DD/MM/YYYY"
                                prepend-icon="event"
                                readonly
                                v-on="on"
                              ></v-text-field>
                            </template>
                            <v-date-picker v-model="editedItem.data" scrollable>
                              <v-spacer></v-spacer>
                              <v-btn color="primary" @click="menuData = false">Cancelar</v-btn>
                              <v-btn color="primary" @click="$refs.dialog.save(editedItem.data)">OK</v-btn>
                            </v-date-picker>
                          </v-dialog>
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field v-model="editedItem.motivo" label="Motivo"></v-text-field>
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field v-model="editedItem.nameMedico" label="Médico responsável"></v-text-field>
                        </v-col>
                      </v-row>
                    </v-container>
                  </v-card-text>

                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="blue darken-1" text @click="close">Cancelar</v-btn>
                    <v-btn color="blue darken-1" text @click="save">Salvar</v-btn>
                  </v-card-actions>
                </v-card>
              </v-dialog>
            </v-toolbar>
          </template>
          <template v-slot:item.action="{ item }">
            <v-icon small class="mr-2" @click="editItem(item)">edit</v-icon>
            <v-icon small @click="deleteItem(item)">delete</v-icon>
          </template>
          <template v-slot:no-data>
            <v-btn color="primary" @click="initialize">Reset</v-btn>
          </template>
        </v-data-table>
      </v-col>
    </v-row>
  </v-app>
</template>

<script>
import moment from 'moment'

export default {
  name: "Consulta",
  data: () => ({
    date: '',
    dialog: false,
    headers: [
      {
        text: 'Nome do Paciente',
        align: 'left',
        sortable: false,
        value: 'namePaciente',
      },
      { text: 'Tipo', value: 'tipo' },
      { text: 'Data de Agendamento', value: 'data' },
      { text: 'Motivo', value: 'motivo' },
      { text: 'Médico responsável', value: 'nameMedico' },
      { text: 'Ações', value: 'action', sortable: false },
    ],
    consultas: [],
    editedIndex: -1,
    menuData: false,
    editedItem: {
      namePaciente: '',
      tipo: '',
      data: new Date().toISOString().substr(0, 10),
      motivo: '',
      nameMedico: '',
    },
    defaultItem: {
      namePaciente: '',
      tipo: '',
      data: new Date().toISOString().substr(0, 10),
      motivo: '',
      nameMedico: '',
    },
  }),

  computed: {
    formTitle () {
      return this.editedIndex === -1 ? 'Nova Consulta' : 'Alterar Dados'
    },
    showData () {
      let dataShow = this.editedItem.data;
      return dataShow ? moment(dataShow).format('DD/MM/YYYY') : ''
    }
  },

  watch: {
    dialog (val) {
      val || this.close()
    },
  },

  created () {
    this.initialize()
  },

  methods: {
    initialize () {
      this.consultas = []
    },

    editItem (item) {
      this.editedIndex = this.consultas.indexOf(item)
      this.editedItem = Object.assign({}, item)
      this.dialog = true
    },

    deleteItem (item) {
      const index = this.consultas.indexOf(item)
      confirm('Confirmar a remoção da consulta?') && this.consultas.splice(index, 1)
    },

    close () {
      this.dialog = false
      setTimeout(() => {
        this.editedItem = Object.assign({}, this.defaultItem)
        this.editedIndex = -1
      }, 300)
    },

    save () {
      if (this.editedIndex > -1) {
        Object.assign(this.consultas[this.editedIndex], this.editedItem)
      } else {
        this.consultas.push(this.editedItem)
      }
      this.close()
    },
  },

};
</script>

<style>
</style>