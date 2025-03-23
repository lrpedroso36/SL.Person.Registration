using SL.Person.Registration.Domain.PersonAggregate.Base;
using System;

namespace SL.Person.Registration.Domain.PersonAggregate;

public class Tratament : Entity
{
    public DateTime Date { get; private set; }

    public bool? Presence { get; private set; }

    public Guid InterviewId { get; set; }
    public Interview Interview { get; set; }

    protected Tratament()
    {

    }

    private Tratament(DateTime date)
    {
        Date = date;
    }

    private Tratament(DateTime date, bool presence) : this(date)
    {
        Presence = presence;
    }

    public static Tratament CreateInstance(DateTime date)
        => new Tratament(date);

    public static Tratament CreateInstance(DateTime date, bool presence)
        => new Tratament(date, presence);

    public void SetPresence(DateTime date)
    {
        Date = date;
        Presence = true;
    }
}
