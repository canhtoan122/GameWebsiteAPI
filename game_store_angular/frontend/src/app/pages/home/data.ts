import { sliderOpt } from 'src/app/shared/data';

export const introSlider = {
    ...sliderOpt,
    nav: false,
    loop: false,
}

export const brandSlider = {
    ...sliderOpt,
    nav: false,
    dots: false,
    margin: 0,
    loop: false,
    responsive: {
        0: {
            items: 2
        },
        420: {
            items: 3
        },
        600: {
            items: 4
        },
        900: {
            items: 5
        },
        1024: {
            items: 6
        },
        1360: {
            items: 7,
            nav: true,
            dots: true
        }
    }
}

export const specialSlider = {
    ...sliderOpt,
    nav: false,
    dots: true,
    margin: 20,
    loop: false,
    responsive: {
        0: {
            items: 2
        },
        480: {
            items: 2
        },
        768: {
            items: 3
        },
        992: {
            items: 4
        },
        1200: {
            items: 5,
            nav: true
        }
    }
}

export const productSlider = {
    ...sliderOpt,
    nav: false,
    dots: true,
    margin: 20,
    loop: false,
    items: 2,
    autoHeight: false,
    responsive: {
        320: {
            items: 2
        },
        480: {
            items: 2
        },
        576: {
            items: 3
        },
        768: {
            items: 4
        },
        1200: {
            items: 5,
            nav: true
        }
    }
}

export const bannerSlider = {
    ...sliderOpt,
    nav: false,
    dots: true,
    margin: 0,
    loop: false,
    items: 1,
    responsive: {
        0: {
            items: 1
        },
        576: {
            items: 2,
            margin: 20
        },
        992: {
            items: 1
        }
    }
}

export const blogSlider = {
    ...sliderOpt,
    nav: false,
    dots: true,
    items: 3,
    margin: 20,
    loop: false,
    autoHeight: false,
    autoplay: false,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 2
        },
        992: {
            items: 3
        },
        1200: {
            items: 4
        }
    }
}