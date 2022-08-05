window.MasaOfficialWebsite = {}

const eventListenerCaches = {}

window.MasaOfficialWebsite.addWindowScrollEvent = (page) => {
  let throttled
  let direction

  const listener = (e) => {
    const innerHeight = window.innerHeight || document.body.clientHeight
    const offsetY = document.body.scrollTop || document.documentElement.scrollTop;

    if (page && offsetY > innerHeight * page) return

    let targetTop = 0;

    const number = Math.ceil(offsetY / innerHeight)
    
    if (direction === 'next') {
      targetTop = innerHeight * number
    } else if (direction === 'previous') {
      targetTop = innerHeight * (number - 1)
    }

    direction = null

    animationScrollTo(targetTop)
  };

  let preOffsetY

  const listenerWrapper = e => {
    const offsetY = document.body.scrollTop || document.documentElement.scrollTop;
    
    if (!preOffsetY) {
      preOffsetY = offsetY
      return
    }

    if (preOffsetY !== offsetY) {
      direction = offsetY > preOffsetY ? 'next' : 'previous'
      preOffsetY = offsetY
    }

    if (!!direction && !throttled) {
      listener(e)
      throttled = true;
      setTimeout(() => {
        throttled = false
      }, 600)
    }
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