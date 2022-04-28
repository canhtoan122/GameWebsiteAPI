import { Component, OnInit, Input } from '@angular/core';

import { Product } from 'src/app/shared/classes/product';

import { bannerSlider } from '../data';

@Component({
	selector: 'molla-new-collection',
	templateUrl: './new-collection.component.html',
	styleUrls: ['./new-collection.component.scss']
})
export class NewCollectionComponent implements OnInit {

	@Input() products: Product[];
	@Input() loaded: boolean;

	bannerSlider = bannerSlider;

	constructor() { }

	ngOnInit(): void {
	}
}
