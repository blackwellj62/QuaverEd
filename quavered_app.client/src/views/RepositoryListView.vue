<template>
  <div class="container py-4">
    <h1 class="h4 mb-3">Repositories</h1>
    <div v-if="loading" class="text-muted">Loading repositories…</div>
    <table v-else class="table table-striped">
      <thead>
        <tr>
          <th>Name</th>
          <th>Owner</th>
          <th>Stars</th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="repo in repositories"
          :key="repo.repositoryId"
          style="cursor: pointer"
          @click="goToDetails(repo.repositoryId)"
        >
          <td>{{ repo.name }}</td>
          <td>{{ repo.ownerUsername }}</td>
          <td>{{ repo.starCount }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
import { ref, onMounted } from "vue";
import { useRouter } from "vue-router";

const repositories = ref([]);
const loading = ref(true);
const router = useRouter();

onMounted(async () => {
  try {
    const response = await fetch("/Repositories");
    repositories.value = await response.json();
  } finally {
    loading.value = false;
  }
});

function goToDetails(id) {
  router.push(`/Repositories/${id}`);
}
</script>
