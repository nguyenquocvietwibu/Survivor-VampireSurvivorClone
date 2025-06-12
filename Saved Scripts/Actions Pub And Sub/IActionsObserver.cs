using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface mô tả chung các khả năng đăng ký - hủy đăng kí các actions
/// </summary>
public interface IActionsObserver
{
    /// <summary>
    /// Đăng kí các action
    /// </summary>
    void SubscribeActions();

    /// <summary>
    /// Hủy đăng kí các action
    /// </summary>
    void UnSubscribeActions();
}
