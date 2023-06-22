<?php

use App\Http\Controllers\DolgozoController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});

Route::prefix('dolgozo')->group(function () {
    Route::get('/', [DolgozoController::class, 'index']);
    Route::get('/{id}', [DolgozoController::class, 'show']);
    Route::post('/create', [DolgozoController::class, 'store']);
    Route::put('/modify/{id}', [DolgozoController::class, 'update']);
    Route::delete('/delete/{id}', [DolgozoController::class,'softDelete']);
    Route::delete('/destroy/{id}', [DolgozoController::class,'destroy']);
});