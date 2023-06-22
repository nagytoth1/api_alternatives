<?php

namespace App\Http\Controllers;

use App\Models\Dolgozo;
use App\Http\Requests\UpdateDolgozoRequest;
use App\Http\Requests\StoreDolgozoRequest;

class DolgozoController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        return response()->json(Dolgozo::all());
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(StoreDolgozoRequest $request)
    {
        $dolg = Dolgozo::create($request->validated());
        if(!$dolg)
            $resp = ['fail' => 'Dolgozó létrehozása sikertelen!'];
        else 
            $resp = ['success' => 'Dolgozó sikeresen létrehozva!'];
        return response()->json($resp, 200);
    } 

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        $dolg = Dolgozo::find($id);
        if(!$dolg) 
            return response()->json(['fail' => 'Dolgozó nem található!'], 400);
        return response()->json($dolg);
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(UpdateDolgozoRequest $request, string $id)
    {        
        $dolg = Dolgozo::find($id);
        if(!$dolg) return response()->json(['fail' => 'Dolgozó nem található!']);
        $dolg->nev = $request['nev'];
        $dolg->reszleg_id = $request['reszleg_id'];
        $dolg->foto = $request['foto'];
        $dolg->save();
        return response()->json(['success' => 'Dolgozó sikeresen módosítva!']);
    }

    /**
     * Remove the specified resource from storage.
     */
    public function softDelete(string $id)
    {
        $dolg = Dolgozo::find($id);
        if(!$dolg) return response()->json(['fail' => 'Dolgozó nem található!']);

        $dolg->delete();
        return response()->json(['success' => 'Dolgozó törlésre került!']);
    }
}
