import { createRouter, createWebHistory } from "vue-router";
import HomePage from "../components/HomePage.vue";
import RepositoryListView from "../views/RepositoryListView.vue";
import RepositoryDetailView from "../views/RepositoryDetailView.vue";
import NotFoundView from "@/views/NotFoundView.vue";

const routes = [
  { path: "/", name: "home", component: HomePage },
  {
    path: "/repositories",
    name: "repositories",
    component: RepositoryListView,
  },
  {
    path: "/repositories/:id",
    name: "repository-details",
    component: RepositoryDetailView,
    props: true,
  },
  {
    path: "/:pathMatch(.*)*",
    name: "not-found",
    component: NotFoundView,
  },
];

export default createRouter({
  history: createWebHistory(),
  routes,
});
