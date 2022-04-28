import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DefaultPageComponent } from './default/default.component';
import { StickyInfoPageComponent } from './sticky-info/sticky-info.component';

const routes: Routes = [
    {
        path: 'default/:slug',
        component: DefaultPageComponent
    },
    {
        path: 'sticky/:slug',
        component: StickyInfoPageComponent
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class ProductRoutingModule { };
