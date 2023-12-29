const body = document.querySelector('body');

function main() {
    document.addEventListener('DOMContentLoaded', function () {
        onScrollHeader();
        showModal();
        scrollToMenuItem();
        showBurger();
        animateAboutText();
        animateScreens();
    });
}
main();
function onScrollHeader () {
    document.addEventListener('scroll', function () {
        var header = document.querySelector('.header');
        if (window.scrollY > 0) {
            header.classList.add('fixed');
        } else {
            header.classList.remove('fixed');
        }
    });    
}
function showModal() {
    const screensImgs = document.querySelectorAll('.screens__item img');
    screensImgs.forEach(item => {
        item.addEventListener('click', (e) => {
            const modal = document.getElementById('modal');
            const modalImage = document.getElementById('modalImage');
            const imageUrl = e.target.src;
            setTimeout(() => {
                modalImage.classList.add('visible');
            }, 0);
            setTimeout(() => {
               document.querySelector('.close').style.opacity = '1'; 
            }, 250);
            modalImage.src = imageUrl;
            modal.style.display = 'flex';
            body.classList.add('lock');
        })
    })
    document.getElementById('modal').addEventListener('click', closeModal);
}
function closeModal(e) {
    const modalImage = document.getElementById('modalImage');
    const modal = document.getElementById('modal');
    const isImageClick = e.target.classList.contains('modal-content');

    if (!isImageClick) {
        body.classList.remove('lock');
        modalImage.classList.remove('visible');
        document.querySelector('.close').style.opacity = '0'; 
        modal.style.display = 'none';
    }
}
function scrollToMenuItem() {
    document.querySelectorAll('a.nav__link').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
    
            const targetId = this.getAttribute('href');
            const targetElement = document.querySelector(targetId);
    
            if (targetElement) {
                const startPos = window.pageYOffset;
                const targetPos = targetElement.offsetTop - document.querySelector('.header').offsetHeight;
                const distance = targetPos - startPos;
    
                let start;
                function step(timestamp) {
                    if (!start) start = timestamp;
                    const progress = timestamp - start;
                    window.scrollTo(0, startPos + easeInOutQuad(progress, 0, distance, 350));
                    if (progress < 350) {
                        requestAnimationFrame(step);
                    }
                }
    
                requestAnimationFrame(step);
            }
        });
    });
}
function easeInOutQuad(t, b, c, d) {
    t /= d / 2;
    if (t < 1) return c / 2 * t * t + b;
    t--;
    return -c / 2 * (t * (t - 2) - 1) + b;
}
function showBurger() {
    const navLinks = document.querySelectorAll('.nav__link');
    navLinks.forEach((link) => {
        link.addEventListener('click', () => {
            nav.classList.remove('active');
            body.classList.remove('lock');
        })
    })

    const nav = document.querySelector('.nav');
    const burger = document.querySelector('.burger');

    burger.addEventListener('click', () => {
        burger.classList.toggle('active');
        nav.classList.toggle('active');
        body.classList.toggle('lock');
        document.querySelector('.header').classList.toggle('active');
    })
}
function animateAboutText() {
    const textElements = document.querySelectorAll('[data-animate]');

    const observer = new IntersectionObserver((entries, observer) => {
        entries.forEach((entry) => {
            if (entry.isIntersecting) {
                entry.target.classList.add('animate-text');
                observer.unobserve(entry.target);
            }
        });
    }, { threshold: 0.5 }); // Порог 0.5 означает, что хотя бы половина элемента должна быть видима
    
    textElements.forEach((textElement) => {
        observer.observe(textElement);
    });
}
function animateScreens() {
    const screens = document.querySelectorAll('.screens__item');

    const observer2 = new IntersectionObserver((entries, observer) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('visible');
                observer.unobserve(entry.target);
            }
        });
    }, { threshold: 0.5 });

    screens.forEach(screen => {
        observer2.observe(screen);
    });
}

