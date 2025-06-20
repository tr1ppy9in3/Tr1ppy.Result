using Tr1ppy.Result.Abstractions;
using Tr1ppy.Result.Markers;

namespace Tr1ppy.Result.Implementations;

/// <summary>
/// Based realization of <see cref="BaseResult{TFault, TValue}"/>
/// </summary>
/// <typeparam name="TFault"> Type of fault. </typeparam>
/// <typeparam name="TValue"> Type of value. </typeparam>
public sealed class Result<TFault, TValue> : BaseResult<TFault, TValue>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TFault, TValue}"/> class representing a failed operation.
    /// </summary>
    /// <param name="fault">The fault object indicating the reason for failure.</param>
    public Result(TFault fault) : base(fault) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TFault, TValue}"/> class representing a successful operation.
    /// </summary>
    /// <param name="value">The success value produced by the operation.</param>
    public Result(TValue value) : base(value) { }

    /// <summary>
    /// Creates a new <see cref="Result{TFault, TValue}"/> instance representing a successful operation with the specified value.
    /// This is a static factory method providing a clear and explicit way to create successful results.
    /// </summary>
    /// <param name="value">The success value.</param>
    /// <returns>A <see cref="Result{TFault, TValue}"/> instance in a success state.</returns>
    public static Result<TFault, TValue> Succeed(TValue value)
        => new(value);

    /// <summary>
    /// Creates a new <see cref="Result{TFault, TValue}"/> instance representing a failed operation with the specified fault.
    /// This is a static factory method providing a clear and explicit way to create failed results.
    /// </summary>
    /// <param name="fault">The fault object.</param>
    /// <returns>A <see cref="Result{TFault, TValue}"/> instance in a failure state.</returns>
    public static Result<TFault, TValue> Fail(TFault fault)
        => new(fault);

    public static implicit operator Result<TFault, TValue>(TValue value)
       => Succeed(value);

    public static implicit operator Result<TFault, TValue>(TFault fault)
       => Fail(fault);

    public static implicit operator Result<TFault, TValue>(SuccessMarker<TValue> successMarker)
       => Succeed(successMarker.Value);

    public static implicit operator Result<TFault, TValue>(FailureMarker<TFault> failureMarker)
       => Fail(failureMarker.Fault);
}
