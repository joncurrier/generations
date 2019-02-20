import Vue from 'vue'
import Router from 'vue-router'
import Recipe from './views/Recipe.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/:slug//',
      name: 'recipe',
      component: Recipe,
      props: true
    }
  ]
})
