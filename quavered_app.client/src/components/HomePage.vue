<template>
  <div class="d-flex align-items-center vh-100">
    <div class="mx-auto">
      <img alt="Q logo" src="./icons/Q_Icon.png" class="align-middle rotate" />
      <div class="fs-5 font-monospace text-center"> QuaverEd, Inc. </div>
    </div>
  </div>
</template>
<style>
 .rotate {
  animation: rotation 3s linear infinite;
}
  @keyframes rotation {
    from {
      transform: rotate3d(0, 1, 0, 0deg);
    }

    to {
      transform: rotate3d(0, 1, 0, 360deg);
    }
  }
</style>
