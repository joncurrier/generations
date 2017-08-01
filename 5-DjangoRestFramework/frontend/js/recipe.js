var api = axios.create({
  baseURL: 'http://127.0.0.1:8080'
});

const Sidebar = {
  template: '#sidebar-template',
  data: function() {
      return {
        categories: []
      }
  },
  mounted: function() {
    this.getCategories();
  },
  methods: {
    getCategories: function() {
      api.get('api/categories').then(response => {
        this.categories = response.data;
      });
    }
  }
}

const Recipe = {
  template: '#recipe-template',
  props: ['slug'],
  data: function () {
    return {
      recipe: {}
    }
  },
  mounted: function() {
    this.getRecipe();
  },
  watch: {
    // call again the method if the route changes
    '$route': 'getRecipe'
  },
  methods: {
    getRecipe: function() {
      api.get('api/recipes/' + this.slug).then(response => {
        this.recipe = response.data;
        document.title = '5 - ' + this.recipe.title;
      });
    }
  }
}

const recipeApp = new Vue({
  router: new VueRouter({
    mode: 'history',
    routes: [
      {
        path: '/:slug//',
        name: 'recipe',
        component: Recipe,
        props: true
      }
    ]
  }),
  components: {
    'vue-sidebar': Sidebar
  }
}).$mount('#content');
