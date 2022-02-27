const observercarousel = new IntersectionObserver(entries => {
    // Loop over the entries
    entries.forEach(entry => {
        // If the element is visible
        if (entry.isIntersecting) {
            // Add the animation class
            entry.target.classList.add('topcarousel-animation');
        }
    });
});

observercarousel.observe(document.querySelector('.topcarousel'));

const observer = new IntersectionObserver(entries => {
    // Loop over the entries
    entries.forEach(entry => {
        // If the element is visible
        if (entry.isIntersecting) {
            // Add the animation class
            entry.target.classList.add('commonblock-animation');
        }
    });
});

observer.observe(document.querySelector('.commonblock'));






const observer1 = new IntersectionObserver(entries => {
    // Loop over the entries
    entries.forEach(entry => {
        // If the element is visible
        if (entry.isIntersecting) {
            // Add the animation class
            entry.target.classList.add('blockodd-animation');
        }
    });
});

observer1.observe(document.querySelector('.blockodd.child1'));

const observer2 = new IntersectionObserver(entries => {
    // Loop over the entries
    entries.forEach(entry => {
        // If the element is visible
        if (entry.isIntersecting) {
            // Add the animation class
            entry.target.classList.add('blockeven-animation');
        }
    });
});

observer2.observe(document.querySelector('.blockeven.child1'));


const observer3 = new IntersectionObserver(entries => {
    // Loop over the entries
    entries.forEach(entry => {
        // If the element is visible
        if (entry.isIntersecting) {
            // Add the animation class
            entry.target.classList.add('blockodd-animation');
        }
    });
});

observer3.observe(document.querySelector('.blockodd.child2'));

const observer4 = new IntersectionObserver(entries => {
    // Loop over the entries
    entries.forEach(entry => {
        // If the element is visible
        if (entry.isIntersecting) {
            // Add the animation class
            entry.target.classList.add('blockeven-animation');
        }
    });
});

observer4.observe(document.querySelector('.blockeven.child2'));








const observer6 = new IntersectionObserver(entries => {
    // Loop over the entries
    entries.forEach(entry => {
        // If the element is visible
        if (entry.isIntersecting) {
            // Add the animation class
            entry.target.classList.add('blockimgodd-animation');
        }
    });
});

observer6.observe(document.querySelector('.blockimgodd.child1'));


const observer7 = new IntersectionObserver(entries => {
    // Loop over the entries
    entries.forEach(entry => {
        // If the element is visible
        if (entry.isIntersecting) {
            // Add the animation class
            entry.target.classList.add('blockimgodd-animation');
        }
    });
});

observer7.observe(document.querySelector('.blockimgodd.child2'));

const observer8 = new IntersectionObserver(entries => {
    // Loop over the entries
    entries.forEach(entry => {
        // If the element is visible
        if (entry.isIntersecting) {
            // Add the animation class
            entry.target.classList.add('blockimgeven-animation');
        }
    });
});

observer8.observe(document.querySelector('.blockimgeven.child1'));

const observer9 = new IntersectionObserver(entries => {
    // Loop over the entries
    entries.forEach(entry => {
        // If the element is visible
        if (entry.isIntersecting) {
            // Add the animation class
            entry.target.classList.add('blockimgeven-animation');
        }
    });
});

observer9.observe(document.querySelector('.blockimgeven.child2'));




const observer5 = new IntersectionObserver(entries => {
    // Loop over the entries
    entries.forEach(entry => {
        // If the element is visible
        if (entry.isIntersecting) {
            // Add the animation class
            entry.target.classList.add('blockodd-animation');
        }
    });
});

observer5.observe(document.querySelector('.blockodd.child3'));


const observer10 = new IntersectionObserver(entries => {
    // Loop over the entries
    entries.forEach(entry => {
        // If the element is visible
        if (entry.isIntersecting) {
            // Add the animation class
            entry.target.classList.add('blockimgodd-animation');
        }
    });
});

observer10.observe(document.querySelector('.blockimgodd.child3'));