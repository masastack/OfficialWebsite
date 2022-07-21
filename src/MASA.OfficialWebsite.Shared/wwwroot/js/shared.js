window.MasaOfficialWebsite = {}

const eventListenerCaches = {}

window.MasaOfficialWebsite.addWindowScrollEvent = (isMobile) => {
  let timeout

  const listener = (e) => {
    const innerHeight = window.innerHeight || document.body.clientHeight
    const offsetY = document.body.scrollTop || document.documentElement.scrollTop;

    let targetTop = 0;

    if (offsetY < innerHeight / 2) {
      targetTop = 0
    } else if (offsetY >= innerHeight / 2 && offsetY < innerHeight * (isMobile ? 1 : 1.5)) {
      targetTop = innerHeight
    } else if (isMobile) {
      return;
    } else if (offsetY >= innerHeight * 1.5 && offsetY < innerHeight * 2) {
      targetTop = innerHeight * 2
    } else {
      return
    }

    animationScrollTo(targetTop)
  };

  const listenerWrapper = e => {
    clearTimeout(timeout)
    timeout = setTimeout(() => listener(e), 300);
  }

  window.addEventListener("scroll", listenerWrapper)

  eventListenerCaches["windowScrollEvent"] = listenerWrapper;
}

window.MasaOfficialWebsite.removeWindowScrollEvent = () => {
  if (eventListenerCaches["windowScrollEvent"]) {
    window.removeEventListener("scroll", eventListenerCaches["windowScrollEvent"])
  }
}

window.MasaOfficialWebsite.scrollToNext = () => {
  const innerHeight = window.innerHeight || document.body.clientHeight
  const offsetY = document.body.scrollTop || document.documentElement.scrollTop;
  const n = Math.ceil((offsetY / innerHeight) || 1)
  animationScrollTo(innerHeight * n)
}

window.MasaOfficialWebsite.scrollTo = (selector) => {
  const dom = document.querySelector(selector)
  if (dom) {
    animationScrollTo(dom.offsetTop)
  }
}

function animationScrollTo(top) {
  const offsetY = document.body.scrollTop || document.documentElement.scrollTop;

  let timer

  const c = offsetY - top
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
}