using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Base;
using MvvmCross.ViewModels;
using MvvmCross.Views;

namespace AlaskaAir.Tests
{
    public class NavigationMockDispatcher
       : IMvxMainThreadDispatcher, IMvxViewDispatcher
    {
        public readonly List<MvxViewModelRequest> Requests = new List<MvxViewModelRequest>();
        public readonly List<MvxPresentationHint> Hints = new List<MvxPresentationHint>();

        public bool IsOnMainThread => true;

        public virtual bool RequestMainThreadAction(Action action,
                                                    bool maskExceptions = true)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception)
            {
                if (!maskExceptions)
                    throw;

                return false;
            }
        }

        public virtual Task<bool> ShowViewModel(MvxViewModelRequest request)
        {
            Requests.Add(request);
            return Task.FromResult(true);
        }

        public virtual Task<bool> ChangePresentation(MvxPresentationHint hint)
        {
            Hints.Add(hint);
            return Task.FromResult(true);
        }

        public Task ExecuteOnMainThreadAsync(Action action, bool maskExceptions = true)
        {
            return Task.Run(() =>
            {
                try
                {
                    action();
                }
                catch (Exception)
                {
                    if (!maskExceptions)
                        throw;
                }
            });
        }

        public async Task ExecuteOnMainThreadAsync(Func<Task> action, bool maskExceptions = true)
        {
            try
            {
                await action();
            }
            catch (Exception)
            {
                if (!maskExceptions)
                    throw;
            }
        }
    }
}
