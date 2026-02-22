using System.ComponentModel;

namespace MauiIcons.Tests.Mocks;

public enum DummyIcon
{
    [Description("\ue000")]
    Home,
    // Test du cas où l'attr Description est absent
    Settings,
}
