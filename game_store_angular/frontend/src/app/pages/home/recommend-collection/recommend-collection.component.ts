import { Component, OnInit, Input } from '@angular/core';

import { Product } from 'src/app/shared/classes/product';

import { productSlider } from '../data';

@Component({
	selector: 'molla-recommend-collection',
	templateUrl: './recommend-collection.component.html',
	styleUrls: ['./recommend-collection.component.scss']
})

export class RecommendCollectionComponent implements OnInit {

	@Input() products: Product[];
	@Input() loaded: boolean;

	productSlider = productSlider;

	constructor() { }

	ngOnInit(): void {
	}
}
