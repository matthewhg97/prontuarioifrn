import Vue from 'vue'
import Router from 'vue-router'
import Login from './views/LoginView.vue'
import Index from './views/IndexView.vue'

Vue.use(Router)

export default new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [
        {
            path: '/',
            name: 'Index',
            component: Index 
        },
        {
            path: '/login',
            name: 'Login',
            component: Login 
        },
        {
            path: '/consulta',
            name: 'Consulta',
            component: () => import('./views/ConsultaView.vue') 
        },
        {
            path: '/contato',
            name: 'Contato',
            component: () => import('./views/ContatoView.vue') 
        },
    ]
})  