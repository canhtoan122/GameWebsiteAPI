import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AboutOneComponent } from './about-one/about-one.component';
import { LoginPageComponent } from './login/login.component';
import { FaqsPageComponent } from './faqs/faqs.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ContactOnePageComponent } from './contact-one/contact-one.component';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'about',
        pathMatch: 'full'
    },
    {
        path: 'about',
        component: AboutOneComponent
    },
    {
        path: '404',
        component: PageNotFoundComponent
    },
    {
        path: 'login',
        component: LoginPageComponent
    },
    {
        path: 'faq',
        component: FaqsPageComponent
    },
    {
        path: 'contact',
        component: ContactOnePageComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class PagesRoutingModule { };
