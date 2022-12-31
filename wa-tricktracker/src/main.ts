import { createApp } from 'vue'
import App from './App.vue'
import router from './router';
import { store, key } from './store';

import "@fortawesome/fontawesome-free/css/all.css";

createApp(App)
  .use(store, key)
  .use(router)
  .mount('#app')
