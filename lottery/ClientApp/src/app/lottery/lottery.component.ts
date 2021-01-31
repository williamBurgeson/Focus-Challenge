import { Component, OnInit } from '@angular/core';
import { LotteryService } from '../lottery.service';
import { FinalResult } from '../models/final-result';
import { PartialResult } from '../models/partial-result';

@Component({
  selector: 'app-lottery',
  templateUrl: './lottery.component.html',
  styleUrls: ['./lottery.component.css']
})
export class LotteryComponent implements OnInit {

  partialResult: PartialResult = { isFull: false };
  finalResult?: FinalResult;


  constructor(private readonly _lotteryService: LotteryService) { }

  ngOnInit() {
  }

  getClass(value: number) {
    if (!value || value < 1) return "empty";
    if (value < 10) return "_1_9";
    if (value < 20) return "_10_19";
    if (value < 30) return "_20_29";
    if (value < 40) return "_30_39";
    return "_40_49";
  }

  getNextBall() {
    this
      ._lotteryService
      .getNextBall(this.partialResult)
      .subscribe(r => this.partialResult = r);
  }

  getFinalResult() {
    this
      ._lotteryService
      .getFinalResult(this.partialResult)
      .subscribe(r => this.finalResult = r);
  }

}
