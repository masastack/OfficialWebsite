window.MasaOfficialWebsite = {}

window.MasaOfficialWebsite.addWindowsScrollEvent = () => {
  let timer
  let timeout

  const listener = (e) => {
    console.log(Date.now())
    const innerHeight = window.innerHeight || document.body.clientHeight
    const offsetY = document.body.scrollTop || document.documentElement.scrollTop;

    let targetTop = 0;

    if (offsetY < innerHeight / 2) {
      targetTop = 0
    } else if (offsetY >= innerHeight / 2 && offsetY < innerHeight * 1.5) {
      targetTop = innerHeight
    } else if (offsetY >= innerHeight * 1.5 && offsetY < innerHeight * 2) {
      targetTop = innerHeight * 2
    } else {
      return
    }

    const c = offsetY - targetTop
    const startTime = +new Date();
    const duration = 500;

    cancelAnimationFrame(timer)

    timer = requestAnimationFrame(function f() {
      const time = duration - Math.max(0, startTime - (+new Date()) + duration);
      document.body.scrollTop = document.documentElement.scrollTop = time * (-c) / duration + offsetY;
      timer = requestAnimationFrame(f)

      if (time === duration) {
        cancelAnimationFrame(timer)
      }
    })
  };

  window.addEventListener("scroll", e => {
    clearTimeout(timeout)
    timeout = setTimeout(() => listener(e), 500);
  })
}

window.MasaOfficialWebsite.removeWindowsScrollEvent = () => {
  // TODO: 需要把listener缓存起来才能删除
  window.removeEventListener("scroll")
}