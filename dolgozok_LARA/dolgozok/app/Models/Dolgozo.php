<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Dolgozo extends Model
{
    use HasFactory, SoftDeletes;

    protected $fillable = ['nev', 'reszleg_id', 'foto'];
    protected $table = 'dolgozo';
    public $timestamps = false;
}
