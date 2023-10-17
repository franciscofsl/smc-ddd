using Semicrol.DddTemplate.Core.Common.ValueObjects;
using Semicrol.DddTemplate.Core.Tests.Shared;
using Shouldly;

namespace Semicrol.DddTemplate.Core.Tests.Common.ValueObjects;

public class RatingsTest
{
    [Fact]
    public void Create_Empty_Ratings_Should_Not_Throw_Exception()
    {
        Should.NotThrow(() => Ratings.Empty);
    }

    [Fact]
    public void Add_Rating_Should_Increase_Count()
    {
        var ratings = Ratings.Empty;
        ratings.AddRating("User1", 4);

        ratings.Values.Count.ShouldBe(1);
    }

    [Fact]
    public void Add_Rating_Should_Throw_Exception_If_User_Already_Rated()
    {
        var ratings = Ratings.Empty;
        ratings.AddRating("User1", 4);

        Should.Throw<ApplicationException>(() => ratings.AddRating("User1", 3))
            .Message.ShouldContain("The user has already rated the product.");
    }

    [Fact]
    public void UserHasRating_Should_Return_True_If_User_Rated()
    {
        var ratings = Ratings.Empty;
        ratings.AddRating("User1", 4);

        var hasRating = ratings.UserHasRating("User1");

        hasRating.ShouldBeTrue();
    }

    [Fact]
    public void UserHasRating_Should_Return_False_If_User_Not_Rated()
    {
        var ratings = Ratings.Empty;

        var hasRating = ratings.UserHasRating("User1");

        hasRating.ShouldBeFalse();
    }

    [Fact]
    public void Get_Atomic_Values_Should_Return_Correct_Values()
    {
        var ratings = Ratings.Empty;
        var rating1 = ratings.AddRating("User1", 4);
        var rating2 = ratings.AddRating("User2", 3);

        var atomicValues = ratings.InvokeGetAtomicValues();

        atomicValues.ShouldNotBeNull();
        atomicValues.ShouldBe(new List<Rating>
        {
            rating1,
            rating2
        });
    }

    [Fact]
    public void RemoveRating_Should_Remove_Rating()
    {
        var ratings = Ratings.Empty;
        ratings.AddRating("User1", 4);

        ratings.RemoveRating("User1");

        ratings.Values.Count.ShouldBe(0);
    }

    [Fact]
    public void RemoveRating_Should_Return_True_If_Rating_Removed()
    {
        var ratings = Ratings.Empty;
        ratings.AddRating("User1", 4);

        var removed = ratings.RemoveRating("User1");

        removed.ShouldBeTrue();
    }

    [Fact]
    public void RemoveRating_Should_Return_False_If_User_Not_Rated()
    {
        var ratings = Ratings.Empty;

        var removed = ratings.RemoveRating("User1");

        removed.ShouldBeFalse();
    }

    [Fact]
    public void RemoveRating_Should_Not_Throw_Exception_If_User_Not_Rated()
    {
        var ratings = Ratings.Empty;

        Should.NotThrow(() => ratings.RemoveRating("User1"));
    }

    [Fact]
    public void Get_Atomic_Values_After_RemoveRating_Should_Return_Correct_Values()
    {
        var ratings = Ratings.Empty;
        ratings.AddRating("User1", 4);
        var rating2 = ratings.AddRating("User2", 3);

        ratings.RemoveRating("User1");

        var atomicValues = ratings.InvokeGetAtomicValues();

        atomicValues.ShouldNotBeNull();
        atomicValues.ShouldBe(new List<Rating>
        {
            rating2
        });
    }
}