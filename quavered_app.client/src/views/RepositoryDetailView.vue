<template>
  <div class="container py-4">
    <div v-if="loading" class="text-muted">Loading repository…</div>

    <div v-else-if="error" class="alert alert-danger">
      {{ error }}
    </div>

    <div v-else>
      <h1 class="h4 mb-3">{{ repo.name }}</h1>

      <p class="text-muted mb-2">
        Owner: <strong>{{ repo.ownerUsername }}</strong>
      </p>

      <p v-if="repo.description" class="mb-3">
        {{ repo.description }}
      </p>

      <ul class="list-group mb-4">
        <li class="list-group-item">⭐ Stars: {{ repo.starCount }}</li>
        <li class="list-group-item">
          Created: {{ formatDate(repo.createdAt) }}
        </li>
        <li class="list-group-item">
          Last Push:
          <span v-if="repo.pushedAt">
            {{ formatDate(repo.pushedAt) }}
          </span>
          <span v-else class="text-muted"> Never </span>
        </li>
      </ul>

      <a
        :href="repo.htmlUrl"
        target="_blank"
        rel="noopener noreferrer"
        class="btn btn-primary"
      >
        View on GitHub
      </a>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from "vue";

const props = defineProps({
  id: {
    type: String,
    required: true,
  },
});

const repo = ref(null);
const loading = ref(true);
const error = ref(null);

onMounted(async () => {
  try {
    const response = await fetch(`/Repositories/${props.id}`);

    if (!response.ok) {
      throw new Error(`Failed to load repository (${response.status})`);
    }

    repo.value = await response.json();
  } catch (e) {
    error.value = e?.message ?? "Unknown error";
  } finally {
    loading.value = false;
  }
});

function formatDate(value) {
  return new Date(value).toLocaleDateString();
}
</script>
