package spring.dolgozo.model;

import jakarta.persistence.*;

@Entity(name = "dolgozojava")
public class Dolgozo {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    @Column(nullable = false)
    private String nev;
    @Column(nullable = false)
    private String foto;
    @Column(nullable = false)
    private int reszleg_id;

    public Dolgozo(String nev, String foto, int reszleg_id) {
        this.nev = nev;
        this.foto = foto;
        this.reszleg_id = reszleg_id;
    }

    public Dolgozo(){}

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public String getFoto() {
        return foto;
    }

    public void setFoto(String foto) {
        this.foto = foto;
    }

    public int getReszleg_id() {
        return reszleg_id;
    }

    public void setReszleg_id(int reszleg_id) {
        this.reszleg_id = reszleg_id;
    }
}
