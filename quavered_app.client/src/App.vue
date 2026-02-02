<template>
  <div>
    <nav class="navbar navbar-expand navbar-dark bg-dark">
      <div class="container">
        <RouterLink class="navbar-brand" to="/">Home</RouterLink>
        <div class="navbar-nav">
          <RouterLink class="nav-link" to="/repositories">Repositories List</RouterLink>
        </div>
      </div>
    </nav>

    <router-view />
  </div>
</template>
