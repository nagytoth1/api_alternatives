<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Reszleg extends Model
{
    use HasFactory;
    protected $table = 'reszleg';
    protected $fillable = ['nev'];
}
